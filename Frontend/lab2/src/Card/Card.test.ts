import { v4 as uuidv4 } from "uuid";
import { Card } from "./Card";

describe("Card", () => {
  describe("editCard", () => {
    const card: Card = {
      id: uuidv4(),
      word: "word",
      translation: "translation",
    };

    const newWord = "hello";
    const newTranslation = "привет";

    it("should update the card with new word and translation", () => {
      const updatedCard = Card.editCard(card, newWord, newTranslation);
      expect(updatedCard).toEqual({
        ...card,
        word: newWord,
        translation: newTranslation,
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
});
