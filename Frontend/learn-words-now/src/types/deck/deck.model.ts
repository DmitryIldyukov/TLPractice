import { Application } from "../application/application.model";
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

export const addDeck = (app: Application, deck: Deck): Application => {
  return { ...app, decks: [...app.decks, deck] };
};

export const deleteDeck = (app: Application, deckId: string): Application => {
  return {
    ...app,
    decks: app.decks.filter((deck) => deck.id !== deckId),
  };
};

export const getDeckById = (decks: Deck[], deckId: string): Deck | undefined => {
  return decks.find((deck) => deck.id === deckId);
};

export const Deck = { editDeck, addDeck, deleteDeck, getDeckById };
