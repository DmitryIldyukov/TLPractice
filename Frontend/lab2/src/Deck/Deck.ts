import { Card } from "../Card/Card";

export type Deck = {
  id: string;
  name: string;

  cards: Card[];
};

export const addCard = (deck: Deck, newCard: Card): Deck => {
  return {
    ...deck,
    cards: [...deck.cards, newCard],
  };
};

export const deleteCard = (deck: Deck, cardId: string): Deck => {
  return {
    ...deck,
    cards: deck.cards.filter(card => card.id !== cardId),
  };
};

export const getCardById = (cards: Card[], cardId: string): Card | undefined => {
  return cards.find(card => card.id === cardId);
};

export const editDeck = (deck: Deck, newName: string): Deck => {
  if (newName === ``) {
    return deck;
  }

  return {
    ...deck,
    name: newName,
  };
};

export const getCards = (deck: Deck): Card[] => {
  return [...deck.cards];
};

export const Deck = { addCard, deleteCard, getCardById, editDeck, getCards };
