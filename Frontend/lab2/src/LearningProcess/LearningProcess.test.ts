import { v4 as uuidv4 } from "uuid";
import { Deck } from "../Deck/Deck";
import { LearningProcess } from "./LearningProcess";

describe("LearningProcess", () => {
  describe("removeCardFromLearningProcess", () => {
    const cardId1 = uuidv4();
    const cardId2 = uuidv4();

    const deck: Deck = {
      id: uuidv4(),
      name: "deck",
      cards: [
        {
          id: cardId1,
          frontSide: "card1",
          backSide: "Карточка1",
        },
        {
          id: cardId2,
          frontSide: "card2",
          backSide: "Карточка2",
        },
      ],
    };

    const emptyDeck: Deck = {
      id: uuidv4(),
      name: "deck",
      cards: [],
    };

    it("should remove the first card from the deck", () => {
      const updatedDeck = LearningProcess.removeCardFromLearningProcess(deck);
      expect(updatedDeck.cards).toEqual([{ id: cardId2, frontSide: "card2", backSide: "Карточка2" }]);
    });

    it("should return an empty array if the deck is empty", () => {
      const updatedDeck = LearningProcess.removeCardFromLearningProcess(emptyDeck);
      expect(updatedDeck.cards).toEqual([]);
    });
  });

  describe("moveCardToBottomOfDeck", () => {
    const cardId1 = uuidv4();
    const cardId2 = uuidv4();

    const deck: Deck = {
      id: uuidv4(),
      name: "deck",
      cards: [
        {
          id: cardId1,
          frontSide: "card1",
          backSide: "Карточка1",
        },
        {
          id: cardId2,
          frontSide: "card2",
          backSide: "Карточка2",
        },
      ],
    };

    it("should move the first card to the bottom of the deck", () => {
      const updatedDeck = LearningProcess.moveCardToDeckBottom(deck);
      expect(updatedDeck.cards).toEqual([
        { id: cardId2, frontSide: "card2", backSide: "Карточка2" },
        { id: cardId1, frontSide: "card1", backSide: "Карточка1" },
      ]);
    });

    it("should return the original deck if the deck is empty", () => {
      const emptyDeck: Deck = {
        id: uuidv4(),
        name: "deck",
        cards: [],
      };
      const updatedDeck = LearningProcess.moveCardToDeckBottom(emptyDeck);
      expect(updatedDeck).toEqual(emptyDeck);
    });
  });
});
