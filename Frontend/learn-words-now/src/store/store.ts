import { create } from "zustand";
import { createJSONStorage, persist } from "zustand/middleware";
import { Deck } from "../types/deck/deck.model";
import { Card } from "../types/card/card.model";
import { immer } from "zustand/middleware/immer";
import { v4 as uuidv4 } from "uuid";
import { Application } from "../types/application/application.model";

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
    immer((set, get) => ({
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
        set({ ...get(), app: Deck.addDeck(get().app, deck) });
      },
      getDeckById: (id: string) => Deck.getDeckById(get().app.decks, id),
      deleteCardById: (deckId: string, id: string) => {
        set({ ...get(), app: Card.deleteCard(get().app, deckId, id) });
      },
      deleteDeckById: (deckId: string) => {
        set({ ...get(), app: Deck.deleteDeck(get().app, deckId) });
      },
      addCard: (deckId: string, card: Card) => {
        set((state) => ({
          ...state,
          app: Card.addCard(state.app, deckId, card),
        }));
      },
    })),
    {
      name: "applicationStore",
      version: 1,
      storage: createJSONStorage(() => localStorage),
    },
  ),
);
