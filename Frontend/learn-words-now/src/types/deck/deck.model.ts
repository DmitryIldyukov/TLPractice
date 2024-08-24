import { Card } from "../card/card.model";

export type Deck = {
  id: string;
  name: string;

  cards: Card[];
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

export const addDeck = (decks: Deck[], deck: Deck): Deck[] => {
  return [...decks, deck];
};

export const deleteDeck = (decks: Deck[], deckId: string): Deck[] => {
  return decks.filter((deck) => deck.id !== deckId);
};

export const getDeckById = (decks: Deck[], deckId: string): Deck | undefined => {
  return decks.find((deck) => deck.id === deckId);
};

export const Deck = { editDeck, addDeck, deleteDeck, getDeckById };
