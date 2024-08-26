import { useState } from "react";
import { useApplicationStore } from "../../../store/store";
import { AddCardComponent } from "../../card/addCardComponent/addCardComponent";
import { CardComponent } from "../../card/cardComponent/cardComponent";
import styles from "./deckInfo.module.scss";
import { LearnProcessComponent } from "../../learnProcessComponent/learnProcessComponent";

type DeckInfoProps = {
  isOpen: boolean;
  id: string;
  onClose: () => void;
};

export const DeckInfo = (props: DeckInfoProps) => {
  const [isAddCardOpen, setIsAddCardOpen] = useState(false);
  const [isLearningProcessOpen, setIsLearningProcessOpen] = useState(false);
  const deck = useApplicationStore().getDeckById(props.id);
  const appStore = useApplicationStore();

  const onDeleteDeck = () => {
    appStore.deleteDeckById(props.id);
  };

  return (
    <div className={props.isOpen ? styles.card : styles.hidden}>
      <div className={styles.content}>
        <div className={styles.topLine}>
          <button className={styles.popupClose} onClick={props.onClose}>
            x
          </button>
        </div>
        <div className={styles.cardInfo}>
          <div className={styles.line}>
            <h3 className={styles.deckName}>{deck?.name}</h3>
            <div className={styles.buttonBox}>
              <button
                className={styles.actionbtn}
                onClick={() => {
                  onDeleteDeck();
                }}
              >
                Удалить
              </button>
              <button
                className={styles.actionbtn}
                onClick={() => {
                  setIsAddCardOpen(true);
                }}
              >
                Добавить карточку
              </button>
              <button
                className={styles.actionbtn}
                onClick={() => {
                  setIsLearningProcessOpen(true);
                }}
              >
                Учить
              </button>
            </div>
          </div>
          <AddCardComponent
            isOpen={isAddCardOpen}
            deckId={props.id}
            onClose={() => {
              setIsAddCardOpen(false);
            }}
          />
          <div className={styles.cardList}>
            {deck?.cards.map((card) => <CardComponent key={card.id} deckId={deck.id} card={card} />)}
          </div>
          <LearnProcessComponent
            deckId={props.id}
            isOpen={isLearningProcessOpen}
            onClose={() => {
              setIsLearningProcessOpen(false);
            }}
          />
        </div>
      </div>
    </div>
  );
};
