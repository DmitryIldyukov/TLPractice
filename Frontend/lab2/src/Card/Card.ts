export type Card = {
  id: string;
  word: string;
  translation: string;
};

export const editCard = (card: Card, newWord: string, newTranslation: string): Card => {
  if (newWord === `` || newTranslation === ``) {
    return card;
  }

  return {
    ...card,
    word: newWord,
    translation: newTranslation,
  };
};

export const Card = { editCard };
