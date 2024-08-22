import { v4 as uuidv4 } from "uuid";
import { Deck } from "./Deck";

describe("Deck", () => {
  describe("editDeck", () => {
    const deck: Deck = {
      id: uuidv4(),
      name: "deck",
      cards: [],
    };

    const newDeckName = "newNameDeck";

    it(`should return an updated deck with a new name`, () => {
      const updatedDeck = Deck.editDeck(deck, newDeckName);
      expect(updatedDeck).toEqual({
        ...deck,
        name: newDeckName,
      });
    });

    it(`should return the original deck if the new name is empty`, () => {
      const updatedDeck = Deck.editDeck(deck, "");
      expect(updatedDeck).toEqual({
        ...deck,
      });
    });
  });

  describe("addDeck", () => {
    const decks: Deck[] = [
      {
        id: uuidv4(),
        name: "deck1",
        cards: [],
      },
    ];

    const deck: Deck = {
      id: uuidv4(),
      name: "deck2",
      cards: [],
    };

    it(`should add a new deck to the array of decks`, () => {
      const application = Deck.addDeck(decks, deck);
      expect(application).toEqual([...decks, deck]);
    });
  });

  describe("deleteDeck", () => {
    const deckId = uuidv4();

    const decks: Deck[] = [{ id: deckId, name: "deck1", cards: [] }];

    it(`should delete a deck from the array of decks`, () => {
      const updatedApp = Deck.deleteDeck(decks, deckId);
      expect(updatedApp).toEqual([]);
    });

    it(`should return the original array of decks if the deck does not exist`, () => {
      const updatedApp = Deck.deleteDeck(decks, "someId");
      expect(updatedApp).toEqual([...decks]);
    });
  });

  describe("getDeckById", () => {
    const deckId = uuidv4();

    const deck: Deck = {
      id: deckId,
      name: "deck1",
      cards: [],
    };

    const decks: Deck[] = [deck];

    it(`should return the deck with the given id if it exists`, () => {
      const existingDeck: Deck | undefined = Deck.getDeckById(decks, deckId);
      expect(existingDeck).toEqual(deck);
    });

    it(`should return undefined if the deck with the given id does not exist`, () => {
      const existingDeck: Deck | undefined = Deck.getDeckById(decks, "someId");
      expect(existingDeck).toEqual(undefined);
    });
  });
});
