import { v4 as uuidv4 } from "uuid";
import { Card } from "../Card/Card";
import { Deck } from "./Deck";

describe("Deck", () => {
  describe("addCard", () => {
    const deck: Deck = {
      id: uuidv4(),
      name: "deck",
      cards: [{ id: uuidv4(), word: "card", translation: "Карточка" }],
    };

    const card: Card = {
      id: uuidv4(),
      word: "word",
      translation: "translation",
    };

    it(`should add a new card to the deck`, () => {
      const newDeck = Deck.addCard(deck, card);
      expect(newDeck).toEqual({
        ...deck,
        cards: [...deck.cards, card],
      });
    });
  });

  describe("deleteCard", () => {
    const cardId = uuidv4();

    const deck: Deck = {
      id: uuidv4(),
      name: "deck",
      cards: [{ id: cardId, word: "card", translation: "Карточка" }],
    };

    it(`should delete a card from the deck`, () => {
      const updatedDeck = Deck.deleteCard(deck, cardId);
      expect(updatedDeck).toEqual({
        ...deck,
        cards: [],
      });
    });

    it(`should return the original deck if the card does not exist`, () => {
      const updatedDeck = Deck.deleteCard(deck, "someId");
      expect(updatedDeck).toEqual({
        ...deck,
      });
    });
  });

  describe("getCardById", () => {
    const cardId = uuidv4();

    const card: Card = {
      id: cardId,
      word: "card",
      translation: "Карточка",
    };

    const deck: Deck = {
      id: uuidv4(),
      name: "deck",
      cards: [card],
    };

    it(`should return the card with the given id if it exists`, () => {
      const existingCard: Card | undefined = Deck.getCardById(deck.cards, cardId);
      expect(existingCard).toEqual(card);
    });

    it(`should return undefined if the card with the given id does not exist`, () => {
      const existingCard: Card | undefined = Deck.getCardById(deck.cards, "someId");
      expect(existingCard).toEqual(undefined);
    });
  });

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

  describe("getCards", () => {
    const id1 = uuidv4();
    const id2 = uuidv4();

    const emptyDeck: Deck = {
      id: uuidv4(),
      name: "deck",
      cards: [],
    };

    const deck: Deck = {
      id: uuidv4(),
      name: "deck",
      cards: [
        {
          id: id1,
          word: "card1",
          translation: "Карточка1",
        },
        {
          id: id2,
          word: "card2",
          translation: "Карточка2",
        },
      ],
    };

    const cards: Card[] = [
      {
        id: id1,
        word: "card1",
        translation: "Карточка1",
      },
      {
        id: id2,
        word: "card2",
        translation: "Карточка2",
      },
    ];

    it(`should return an empty array if the deck has no cards`, () => {
      const deckCards: Card[] = Deck.getCards(emptyDeck);
      expect(deckCards).toEqual([]);
    });

    it(`should return all cards from the deck`, () => {
      const deckCards: Card[] = Deck.getCards(deck);
      expect(deckCards).toEqual(cards);
    });
  });
});
