import { Deck } from "../Deck/Deck";

export type Application = {
  decks: Deck[];
};

export const addDeck = (app: Application, deck: Deck): Application => {
  return {
    ...app,
    decks: [...app.decks, deck],
  };
};

export const deleteDeck = (app: Application, deckId: string): Application => {
  return {
    ...app,
    decks: app.decks.filter(deck => deck.id !== deckId),
  };
};

export const getDeckById = (app: Application, deckId: string): Deck | undefined => {
  return app.decks.find(deck => deck.id === deckId);
};

export const getAllDecks = (application: Application): Deck[] => {
  return [...application.decks];
};

export const Application = { addDeck, deleteDeck, getDeckById, getAllDecks };
