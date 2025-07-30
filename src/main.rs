use mastermind::logic::game::Game;

#[derive(Debug, Clone, PartialEq, Eq, Hash)]
pub enum Color {
    RED,
    BLUE,
    GREEN,
    ORANGE,
    PURPLE,
    YELLOW
}

fn main() {
    let mut game = Game::new(vec![Color::RED, Color::RED, Color::RED, Color::RED], 10);
    println!("{:?}", game);
}
