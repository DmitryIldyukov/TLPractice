import { Deck } from "../Deck/Deck";
import { Application } from "./Application";
import { v4 as uuidv4 } from "uuid";

describe("Application", () => {
  describe("addDeck", () => {
    const app: Application = {
      decks: [
        {
          id: uuidv4(),
          name: "deck1",
          cards: [],
        },
      ],
    };

    const deck: Deck = {
      id: uuidv4(),
      name: "deck2",
      cards: [],
    };

    it(`should add a new deck to the application`, () => {
      const application = Application.addDeck(app, deck);
      expect(application).toEqual({
        ...app,
        decks: [...app.decks, deck],
      });
    });
  });

  describe("deleteDeck", () => {
    const deckId = uuidv4();

    const app: Application = {
      decks: [
        {
          id: deckId,
          name: "deck1",
          cards: [],
        },
      ],
    };

    it(`should delete a deck from the application`, () => {
      const updatedApp = Application.deleteDeck(app, deckId);
      expect(updatedApp).toEqual({
        ...app,
        decks: [],
      });
    });

    it(`should return the original application if the deck does not exist`, () => {
      const updatedApp = Application.deleteDeck(app, "someId");
      expect(updatedApp).toEqual({
        ...app,
      });
    });
  });

  describe("getDeckById", () => {
    const deckId = uuidv4();

    const deck: Deck = {
      id: deckId,
      name: "deck1",
      cards: [],
    };

    const app: Application = {
      decks: [deck],
    };

    it(`should return the deck with the given id if it exists`, () => {
      const existingDeck: Deck | undefined = Application.getDeckById(app, deckId);
      expect(existingDeck).toEqual(deck);
    });

    it(`should return undefined if the deck with the given id does not exist`, () => {
      const existingDeck: Deck | undefined = Application.getDeckById(app, "someId");
      expect(existingDeck).toEqual(undefined);
    });
  });

  describe("getAllDecks", () => {
    const id1 = uuidv4();
    const id2 = uuidv4();

    const emptyApp: Application = {
      decks: [],
    };

    const app: Application = {
      decks: [
        {
          id: id1,
          name: "deck1",
          cards: [],
        },
        {
          id: id2,
          name: "deck2",
          cards: [],
        },
      ],
    };

    const decks: Deck[] = [
      {
        id: id1,
        name: "deck1",
        cards: [],
      },
      {
        id: id2,
        name: "deck2",
        cards: [],
      },
    ];

    it(`should return an empty array if the application has no decks`, () => {
      const applicationDecks: Deck[] = Application.getAllDecks(emptyApp);
      expect(applicationDecks).toEqual([]);
    });

    it(`should return all decks from the application`, () => {
      const applicationDecks: Deck[] = Application.getAllDecks(app);
      expect(applicationDecks).toEqual(decks);
    });
  });
});
