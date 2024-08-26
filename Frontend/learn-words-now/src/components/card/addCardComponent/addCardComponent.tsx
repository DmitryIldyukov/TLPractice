import { useState } from "react";
import styles from "./addCardComponent.module.scss";
import { useApplicationStore } from "../../../store/store";
import { Card } from "../../../types/card/card.model";
import { v4 as uuidv4 } from "uuid";

type AddCardComponentProps = {
  isOpen: boolean;
  deckId: string;
  onClose: () => void;
};

export const AddCardComponent = (props: AddCardComponentProps) => {
  const [frontSide, setFrontSide] = useState("");
  const [backSide, setBackSide] = useState("");
  const appStore = useApplicationStore();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (!frontSide.trim() || !backSide.trim()) {
      alert("Оба поля должны быть заполнены.");
      return;
    }

    const newCard: Card = {
      id: uuidv4(),
      frontSide,
      backSide,
    };

    appStore.addCard(props.deckId, newCard);

    setFrontSide("");
    setBackSide("");

    props.onClose();
  };

  return (
    <form className={props.isOpen ? styles.form : styles.hidden}>
      <div className={styles.inputGroup}>
        <label htmlFor="frontSide" className={styles.lable}>
          Слово:
        </label>
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
        <label htmlFor="translation" className={styles.lable}>
          Перевод слова:
        </label>
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
      <div className={styles.btnGroup}>
        <button className={styles.submitBtn} onClick={handleSubmit}>
          Добавить
        </button>
        <button type="button" className={styles.closeBtn} onClick={props.onClose}>
          Отменить
        </button>
      </div>
    </form>
  );
};
