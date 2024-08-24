import { create } from "zustand";
import { createJSONStorage, persist } from "zustand/middleware";
import { Deck } from "../types/deck/deck.model";
import { immer } from "zustand/middleware/immer";
import { v4 as uuidv4 } from "uuid";

type ApplicationStore = {
  decks: Deck[];
  addDeck: (deck: Deck) => void;
};

export const useApplicationStore = create<ApplicationStore>()(
  persist(
    immer((set) => ({
      decks: [{ id: uuidv4(), name: "Программирование", cards: [] }],
      addDeck: (deck: Deck) => {
        set((state) => {
          state.decks.push(deck);
        });
      },
    })),
    {
      name: "applicationStore",
      version: 1,
      storage: createJSONStorage(() => localStorage),
    },
  ),
);
