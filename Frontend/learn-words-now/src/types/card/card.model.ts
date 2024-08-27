import { Application } from "../application/application.model";
import { Deck } from "../deck/deck.model";

export type Card = {
  id: string;
  frontSide: string;
  backSide: string;
};

export const addCard = (app: Application, deckId: string, newCard: Card): Application => {
  const deck = Deck.getDeckById(app.decks, deckId);

  if (deck && newCard.frontSide !== "" && newCard.backSide !== "") {
    const updatedDecks = app.decks.map((d) => (d.id === deckId ? { ...d, cards: [...d.cards, newCard] } : d));
    return { ...app, decks: updatedDecks };
  }

  return app;
};

export const getCardById = (app: Application, deckId: string, cardId: string): Card | undefined => {
  const deck = Deck.getDeckById(app.decks, deckId);
  return deck?.cards.find((card) => card.id === cardId);
};

export const editCard = (
  app: Application,
  deckId: string,
  cardId: string,
  newWord: string,
  newTranslation: string,
): Application => {
  const deck = Deck.getDeckById(app.decks, deckId);

  if (deck && newWord !== "" && newTranslation !== "") {
    const updatedDecks = app.decks.map((d) =>
      d.id === deckId
        ? {
            ...d,
            cards: d.cards.map((c) => (c.id === cardId ? { ...c, frontSide: newWord, backSide: newTranslation } : c)),
          }
        : d,
    );
    return { ...app, decks: updatedDecks };
  }

  return app;
};

export const deleteCard = (app: Application, deckId: string, cardId: string): Application => {
  const deck = Deck.getDeckById(app.decks, deckId);

  if (deck) {
    const updatedDecks = app.decks.map((d) =>
      d.id === deckId
        ? {
            ...d,
            cards: d.cards.filter((card) => card.id !== cardId),
          }
        : d,
    );
    return { ...app, decks: updatedDecks };
  }

  return app;
};

export const Card = { addCard, getCardById, editCard, deleteCard };
