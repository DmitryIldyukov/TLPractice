import { Deck } from "../Deck/Deck";

export type LearningProcess = {
  deck: Deck;
};

export const removeCardFromLearningProcess = (deck: Deck): Deck => {
  return {
    ...deck,
    cards: deck.cards.slice(1),
  };
};

export const moveCardToDeckBottom = (deck: Deck): Deck => {
  return {
    ...deck,
    cards: [...deck.cards.slice(1), deck.cards[0]],
  };
};

export const LearningProcess = { removeCardFromLearningProcess, moveCardToDeckBottom };
