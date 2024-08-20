import { Card } from "../Card/Card";
import { Deck } from "../Deck/Deck";

export type LearningProcess = {
  deck: Deck;
}

export const removeCardFromLearningProcess = (deck: Deck): Deck => {
  return {
    ...deck,
    cards: deck.cards.slice(1) 
  }
};

export const moveCardToBottomOfDeck = (deck: Deck): Deck => {
  return {
    ...deck,
    cards: [...deck.cards.slice(1), deck.cards[0]]
  }
};