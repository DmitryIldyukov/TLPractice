import { v4 as uuidv4 } from "uuid";
import { Card } from "./Card";

describe("Card", () => {
  describe("editCard", () => {
    const card: Card = {
      id: uuidv4(),
      frontSide: "word",
      backSide: "translation",
    };

    const newWord = "hello";
    const newTranslation = "привет";

    it("should update the card with new word and translation", () => {
      const updatedCard = Card.editCard(card, newWord, newTranslation);
      expect(updatedCard).toEqual({
        ...card,
        frontSide: newWord,
        backSide: newTranslation,
      });
    });

    it("should return the original card if newWord or newTranslation is empty", () => {
      const updatedCard = Card.editCard(card, "", newTranslation);
      expect(updatedCard).toEqual(card);

      const updatedCard2 = Card.editCard(card, newWord, "");
      expect(updatedCard2).toEqual(card);

      const updatedCard3 = Card.editCard(card, "", "");
      expect(updatedCard3).toEqual(card);
    });
  });

  describe("addCard", () => {
    const cards: Card[] = [{ id: uuidv4(), frontSide: "card", backSide: "Карточка" }];

    const card: Card = {
      id: uuidv4(),
      frontSide: "word",
      backSide: "translation",
    };

    it(`should add a new card to the array of cards`, () => {
      const newDeck = Card.addCard(cards, card);
      expect(newDeck).toEqual([...cards, card]);
    });
  });

  describe("deleteCard", () => {
    const cardId = uuidv4();

    const cards: Card[] = [{ id: cardId, frontSide: "card", backSide: "Карточка" }];

    it(`should delete a card from the array of cards`, () => {
      const updatedDeck = Card.deleteCard(cards, cardId);
      expect(updatedDeck).toEqual([]);
    });

    it(`should return the original array of cards if the card does not exist`, () => {
      const updatedDeck = Card.deleteCard(cards, "someId");
      expect(updatedDeck).toEqual([...cards]);
    });
  });

  describe("getCardById", () => {
    const cardId = uuidv4();

    const card: Card = {
      id: cardId,
      frontSide: "card",
      backSide: "Карточка",
    };

    const cards: Card[] = [card];

    it(`should return the card with the given id if it exists`, () => {
      const existingCard: Card | undefined = Card.getCardById(cards, cardId);
      expect(existingCard).toEqual(card);
    });

    it(`should return undefined if the card with the given id does not exist`, () => {
      const existingCard: Card | undefined = Card.getCardById(cards, "someId");
      expect(existingCard).toEqual(undefined);
    });
  });
});
