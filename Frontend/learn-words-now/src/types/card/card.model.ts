export interface Card {
  id: string;
  frontSide: string;
  backSide: string;
}

export const addCard = (cards: Card[], newCard: Card): Card[] => {
  return [...cards, newCard];
};

export const getCardById = (cards: Card[], cardId: string): Card | undefined => {
  return cards.find((card) => card.id === cardId);
};

export const editCard = (card: Card, newWord: string, newTranslation: string): Card => {
  if (newWord === `` || newTranslation === ``) {
    return card;
  }

  return {
    ...card,
    frontSide: newWord,
    backSide: newTranslation,
  };
};

export const deleteCard = (cards: Card[], cardId: string): Card[] => {
  return cards.filter((card) => card.id !== cardId);
};

export const Card = { addCard, getCardById, editCard, deleteCard };
