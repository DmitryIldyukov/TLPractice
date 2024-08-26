import { useState, useEffect } from "react";
import styles from "./learnProcessComponent.module.scss";
import { useApplicationStore } from "../../store/store";
import { Card } from "../../types/card/card.model";
import { LearningProcess } from "../../types/learningProcess/learningProcess.model";

type LearnProcessProps = {
  deckId: string;
  isOpen: boolean;
  onClose: () => void;
};

export const LearnProcessComponent = (props: LearnProcessProps) => {
  const appStore = useApplicationStore();
  const [deck, setDeck] = useState(appStore.getDeckById(props.deckId));
  const [shuffledCards, setShuffledCards] = useState<Card[]>([]);
  const [currentCardIndex, setCurrentCardIndex] = useState(0);
  const [isFlipped, setIsFlipped] = useState(false);

  useEffect(() => {
    if (!props.isOpen) {
      setDeck(appStore.getDeckById(props.deckId));
      setShuffledCards([]);
      setCurrentCardIndex(0);
      setIsFlipped(false);
    }
  }, [props.isOpen, props.deckId, appStore]);

  useEffect(() => {
    if (deck && props.isOpen) {
      const shuffled = [...deck.cards].sort(() => Math.random() - 0.5);
      setShuffledCards(shuffled);
      setCurrentCardIndex(0);
      setIsFlipped(false);
    }
  }, [deck, props.isOpen]);

  const handleFlip = () => {
    setIsFlipped(!isFlipped);
  };

  const handleAnswer = (knewTranslation: boolean) => {
    let updatedShuffledCards = [...shuffledCards];

    if (knewTranslation) {
      updatedShuffledCards = LearningProcess.removeCardFromLearningProcess(updatedShuffledCards);
    } else {
      updatedShuffledCards = LearningProcess.moveCardToDeckBottom(updatedShuffledCards);
    }

    setShuffledCards(updatedShuffledCards);
    setIsFlipped(false);

    if (currentCardIndex >= updatedShuffledCards.length - 1) {
      setCurrentCardIndex(0);
    }
  };

  const currentCard = shuffledCards[currentCardIndex];

  if (!props.isOpen) return null;

  return (
    <div className={styles.container}>
      {shuffledCards.length === 0 ? (
        <div className={styles.content}>
          <p>Вы изучили все карточки!</p>
          <button onClick={props.onClose}>Закрыть</button>
        </div>
      ) : (
        <div className={styles.content}>
          <div className={styles.card} onClick={handleFlip}>
            <p className={styles.cardName}>{isFlipped ? currentCard.backSide : currentCard.frontSide}</p>
          </div>
          <div className={styles.question}>
            <p className={styles.questionTitle}>Знали ли вы перевод данного слова?</p>
            <div className={styles.buttons}>
              <button
                className={styles.actionBtn}
                onClick={() => {
                  handleAnswer(true);
                }}
              >
                Да
              </button>
              <button
                className={styles.actionBtn}
                onClick={() => {
                  handleAnswer(false);
                }}
              >
                Нет
              </button>
            </div>
          </div>
          <button className={styles.actionBtn} onClick={props.onClose}>
            Закрыть
          </button>
        </div>
      )}
    </div>
  );
};
