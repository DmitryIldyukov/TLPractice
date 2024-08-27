import { Card } from "../card/card.model";
import { Deck } from "../deck/deck.model";

export type LearningProcess = {
  deck: Deck;
};

export const removeCardFromLearningProcess = (cards: Card[]): Card[] => {
  return cards.slice(1);
};

export const moveCardToDeckBottom = (cards: Card[]): Card[] => {
  return [...cards.slice(1), cards[0]];
};

export const LearningProcess = { removeCardFromLearningProcess, moveCardToDeckBottom };
