import React, { useState, useEffect } from "react";
import styles from "./learnProcessComponent.module.scss";
import { useApplicationStore } from "../../store/store";
import { Card } from "../../types/card/card.model";
import { LearningProcess } from "../../types/learningProcess/learningProcess.model";

export const LearnProcessComponent = ({
  deckId,
  isOpen,
  onClose,
}: {
  deckId: string;
  isOpen: boolean;
  onClose: () => void;
}) => {
  const appStore = useApplicationStore();
  const [deck, setDeck] = useState(appStore.getDeckById(deckId));
  const [shuffledCards, setShuffledCards] = useState<Card[]>([]);
  const [currentCardIndex, setCurrentCardIndex] = useState(0);
  const [isFlipped, setIsFlipped] = useState(false);

  useEffect(() => {
    if (!isOpen) {
      setDeck(appStore.getDeckById(deckId));
      setShuffledCards([]);
      setCurrentCardIndex(0);
      setIsFlipped(false);
    }
  }, [isOpen, deckId, appStore]);

  useEffect(() => {
    if (deck && isOpen) {
      const shuffled = [...deck.cards].sort(() => Math.random() - 0.5);
      setShuffledCards(shuffled);
      setCurrentCardIndex(0);
      setIsFlipped(false);
    }
  }, [deck, isOpen]);

  const handleFlip = () => {
    setIsFlipped(!isFlipped);
  };

  const handleAnswer = (knewTranslation: boolean) => {
    if (deck) {
      const updatedDeck = knewTranslation
        ? LearningProcess.removeCardFromLearningProcess(deck)
        : LearningProcess.moveCardToDeckBottom(deck);

      setDeck(updatedDeck);
    }

    setIsFlipped(false);
    setCurrentCardIndex((prevIndex) => prevIndex + 1);
  };

  const currentCard = shuffledCards[currentCardIndex];

  if (!isOpen) return null;

  return (
    <div className={styles.container}>
      {!currentCard ? (
        <div className={styles.content}>
          <p>Вы изучили все карточки!</p>
          <button
            onClick={() => {
              onClose();
            }}
          >
            Закрыть
          </button>
        </div>
      ) : (
        <div className={styles.content}>
          <div className={styles.card} onClick={handleFlip}>
            <p>{isFlipped ? currentCard.backSide : currentCard.frontSide}</p>
          </div>
          <div className={styles.question}>
            <p>Знали ли вы перевод данного слова?</p>
            <div className={styles.buttons}>
              <button
                onClick={() => {
                  handleAnswer(true);
                }}
              >
                Да
              </button>
              <button
                onClick={() => {
                  handleAnswer(false);
                }}
              >
                Нет
              </button>
            </div>
          </div>
          <button onClick={onClose}>Закрыть</button>
        </div>
      )}
    </div>
  );
};
