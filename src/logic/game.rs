use std::{collections::HashMap, hash::Hash};

#[derive(Debug, Copy, Clone, PartialEq, Eq)]
pub enum GameStatus {
    InProgress,
    Won,
    Lost,
}

#[derive(Debug, Copy, Clone, PartialEq, Eq)]
pub struct GuessResult {
    pub exact: usize,
    pub partial: usize,
}

#[derive(Debug)]
pub struct Attempt<T> {
    pub guess: Vec<T>,
    pub result: GuessResult,
}

#[derive(Debug)]
pub enum GameError {
    InvalidLength { expected: usize, got: usize },
    MaxAttemptsReached,
}

#[derive(Debug)]
pub struct Game<T> {
    secret: Vec<T>,
    max_attempts: u8,
    attempts: Vec<Attempt<T>>,
    status: GameStatus,
}

impl<T> Game<T>
where
    T: Eq + Hash + Clone,
{
    pub fn new(secret: Vec<T>, max_attempts: u8) -> Self {
        Self {
            secret,
            max_attempts,
            attempts: Vec::new(),
            status: GameStatus::InProgress,
        }
    }

    fn evaluate_guess(&self, guess: &[T]) -> GuessResult {
        let mut exact = 0;
        let mut guess_counts: HashMap<&T, usize> = HashMap::new();
        let mut secret_counts: HashMap<&T, usize> = HashMap::new();

        for (g, s) in guess.iter().zip(self.secret.iter()) {
            if g == s {
                exact += 1;
            } else {
                *guess_counts.entry(g).or_insert(0) += 1;
                *secret_counts.entry(s).or_insert(0) += 1;
            }
        }

        let partial = guess_counts
            .iter()
            .map(|(value, &g_count)| {
                secret_counts.get(value).map_or(0, |&s_count| g_count.min(s_count))
            })
            .sum();

        GuessResult { exact, partial }
    }

    pub fn make_guess(&mut self, guess: Vec<T>) -> Result<GuessResult, GameError> {
        if self.attempts.len() as u8 >= self.max_attempts || self.status != GameStatus::InProgress {
            return Err(GameError::MaxAttemptsReached);
        }

        if guess.len() != self.secret.len() {
            return Err(GameError::InvalidLength {
                expected: self.secret.len(),
                got: guess.len(),
            });
        }

        let result = self.evaluate_guess(&guess);
        self.attempts.push(Attempt {
            guess,
            result,
        });

        if result.exact == self.secret.len() {
            self.status = GameStatus::Won;
        } else if self.attempts.len() as u8 >= self.max_attempts {
            self.status = GameStatus::Lost;
        }

        Ok(result)
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[derive(Debug, PartialEq, Eq, Hash, Clone)]
    enum Token {
        Red,
        Green,
        Blue,
        Yellow,
    }

    #[test]
    fn test_all_exact() {
        let mut game = Game::new(vec!["R", "G", "B", "Y"], 10);
        let result = game.make_guess(vec!["R", "G", "B", "Y"]).unwrap();
        assert_eq!(result, GuessResult { exact: 4, partial: 0 });
        assert!(matches!(game.status, GameStatus::Won));
    }

    #[test]
    fn test_game_over_after_win() {
        let mut game = Game::new(vec!["R", "G"], 10);
        let _ = game.make_guess(vec!["R", "G"]).unwrap();
        let err = game.make_guess(vec!["G", "R"]).unwrap_err();
        assert!(matches!(err, GameError::MaxAttemptsReached));
    }

    #[test]
    fn test_custom_type_exact_match() {
        use Token::*;
        let mut game = Game::new(vec![Red, Green, Blue], 3);
        let result = game.make_guess(vec![Red, Green, Blue]).unwrap();
        assert_eq!(result, GuessResult { exact: 3, partial: 0 });
        assert!(matches!(game.status, GameStatus::Won));
    }

    #[test]
    fn test_custom_type_partial_match() {
        use Token::*;
        let mut game = Game::new(vec![Red, Green, Blue], 3);
        let result = game.make_guess(vec![Green, Blue, Red]).unwrap();
        assert_eq!(result, GuessResult { exact: 0, partial: 3 });
        assert!(matches!(game.status, GameStatus::InProgress));
    }


    #[test]
    fn test_all_partial() {
        let mut game = Game::new(vec!["R", "G", "B", "Y"], 10);
        let result = game.make_guess(vec!["G", "B", "Y", "R"]).unwrap();
        assert_eq!(result, GuessResult { exact: 0, partial: 4 });
        assert!(matches!(game.status, GameStatus::InProgress));
    }

    #[test]
    fn test_partial_and_exact() {
        let mut game = Game::new(vec!["R", "G", "B", "Y"], 10);
        let result = game.make_guess(vec!["R", "B", "G", "W"]).unwrap();
        assert_eq!(result, GuessResult { exact: 1, partial: 2 });
    }

    #[test]
    fn test_invalid_length() {
        let mut game = Game::new(vec!["R", "G", "B", "Y"], 10);
        let err = game.make_guess(vec!["R", "G"]).unwrap_err();
        assert!(matches!(err, GameError::InvalidLength { .. }));
    }

    #[test]
    fn test_max_attempts_reached() {
        let mut game = Game::new(vec!["R", "G"], 1);
        let _ = game.make_guess(vec!["R", "B"]);
        let err = game.make_guess(vec!["G", "R"]).unwrap_err();
        assert!(matches!(err, GameError::MaxAttemptsReached));
    }

    #[test]
    fn test_no_match() {
        let mut game = Game::new(vec!["R", "G", "B", "Y"], 10);
        let result = game.make_guess(vec!["O", "O", "O", "O"]).unwrap();
        assert_eq!(result, GuessResult { exact: 0, partial: 0 });
    }

    #[test]
    fn test_duplicate_guess_against_single_secret_color() {
        let mut game = Game::new(vec!["R", "G", "B", "Y"], 10);
        let result = game.make_guess(vec!["R", "R", "R", "R"]).unwrap();
        assert_eq!(result, GuessResult { exact: 1, partial: 0 });
    }

    #[test]
    fn test_duplicate_guess_with_one_exact_and_no_partial() {
        let mut game = Game::new(vec!["G", "B", "C", "D"], 10);
        let result = game.make_guess(vec!["G", "G", "G", "G"]).unwrap();
        assert_eq!(result, GuessResult { exact: 1, partial: 0 });
    }

    #[test]
    fn test_game_lost() {
        let mut game = Game::new(vec!["A", "B"], 2);
        let _ = game.make_guess(vec!["X", "Y"]);
        let _ = game.make_guess(vec!["X", "Y"]);
        assert!(matches!(game.status, GameStatus::Lost));
    }

    #[test]
    fn test_game_history() {
        let mut game = Game::new(vec!["A", "B"], 2);
        let _ = game.make_guess(vec!["B", "A"]);
        assert_eq!(game.attempts.len(), 1);
        assert_eq!(game.attempts[0].result, GuessResult { exact: 0, partial: 2 });
    }
}
