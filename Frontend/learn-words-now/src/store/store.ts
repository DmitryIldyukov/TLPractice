import { create } from "zustand";
import { createJSONStorage, persist } from "zustand/middleware";
import { Deck } from "../types/deck/deck.model";
import { Card } from "../types/card/card.model";
import { v4 as uuidv4 } from "uuid";
import { Application } from "../types/application/application.model";
import { produce } from "immer";

type ApplicationStore = {
  app: Application;
  addDeck: (deck: Deck) => void;
  getDeckById: (id: string) => Deck | undefined;
  addCard: (deckId: string, card: Card) => void;
  deleteCardById: (deckId: string, id: string) => void;
  deleteDeckById: (deckId: string) => void;
};

export const useApplicationStore = create<ApplicationStore>()(
  persist(
    (set, get) => ({
      app: {
        decks: [
          {
            id: uuidv4(),
            name: "Программирование",
            cards: [
              {
                id: uuidv4(),
                frontSide: "Программист",
                backSide: "Programmer",
              },
              {
                id: uuidv4(),
                frontSide: "Программирование",
                backSide: "Programming",
              },
            ],
          },
        ],
      },

      addDeck: (deck: Deck) => {
        set((state) =>
          produce(state, (draft: ApplicationStore) => {
            draft.app.decks.push(deck);
          }),
        );
      },

      getDeckById: (id: string) => get().app.decks.find((deck) => deck.id === id),

      addCard: (deckId: string, card: Card) => {
        set((state) =>
          produce(state, (draft: ApplicationStore) => {
            const deck = draft.app.decks.find((deck) => deck.id === deckId);
            if (deck) {
              deck.cards.push(card);
            }
          }),
        );
      },

      deleteCardById: (deckId: string, id: string) => {
        set((state) =>
          produce(state, (draft: ApplicationStore) => {
            const deck = draft.app.decks.find((deck) => deck.id === deckId);
            if (deck) {
              deck.cards = deck.cards.filter((card) => card.id !== id);
            }
          }),
        );
      },

      deleteDeckById: (deckId: string) => {
        set((state) =>
          produce(state, (draft: ApplicationStore) => {
            draft.app.decks = draft.app.decks.filter((deck) => deck.id !== deckId);
          }),
        );
      },
    }),
    {
      name: "applicationStore",
      version: 1,
      storage: createJSONStorage(() => localStorage),
    },
  ),
);
