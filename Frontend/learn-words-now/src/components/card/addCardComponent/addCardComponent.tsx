import { useState } from "react";
import styles from "./addCardComponent.module.scss";
import { useApplicationStore } from "../../../store/store";
import { Card } from "../../../types/card/card.model";
import { v4 as uuidv4 } from "uuid";

export const AddCardComponent = ({
  isOpen,
  deckId,
  onClose,
}: {
  isOpen: boolean;
  deckId: string;
  onClose: () => void;
}) => {
  const [frontSide, setFrontSide] = useState("");
  const [backSide, setBackSide] = useState("");
  const appStore = useApplicationStore();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    const newCard: Card = {
      id: uuidv4(),
      frontSide,
      backSide,
    };

    appStore.addCard(deckId, newCard);

    setFrontSide("");
    setBackSide("");

    onClose();
  };

  return (
    <form className={isOpen ? styles.form : styles.hidden}>
      <div className={styles.inputGroup}>
        <label htmlFor="frontSide">Слово:</label>
        <input
          type="text"
          id="frontSide"
          value={frontSide}
          onChange={(e) => {
            setFrontSide(e.target.value);
          }}
          className={styles.input}
        />
      </div>
      <div className={styles.inputGroup}>
        <label htmlFor="translation">Перевод слова:</label>
        <input
          type="text"
          id="backSide"
          value={backSide}
          onChange={(e) => {
            setBackSide(e.target.value);
          }}
          className={styles.input}
        />
      </div>
      <button className={styles.submitBtn} onClick={handleSubmit}>
        Добавить
      </button>
      <button type="button" className={styles.closeBtn} onClick={onClose}>
        Отменить
      </button>
    </form>
  );
};
