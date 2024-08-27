import { useState } from "react";
import styles from "./addDeckComponent.module.scss";
import { useApplicationStore } from "../../../store/store";
import { Deck } from "../../../types/deck/deck.model";
import { v4 as uuidv4 } from "uuid";

type AddDeckComponentProps = {
  isOpen: boolean;
  onClose: () => void;
};

export const AddDeckComponent = (props: AddDeckComponentProps) => {
  const [deckName, setDeckName] = useState("");
  const appStore = useApplicationStore();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    const newDeck: Deck = {
      id: uuidv4(),
      name: deckName,
      cards: [],
    };

    appStore.addDeck(newDeck);

    setDeckName("");

    props.onClose();
  };

  return (
    <form className={props.isOpen ? styles.form : styles.hidden}>
      <label htmlFor="deckName">Название колоды:</label>
      <input
        type="text"
        id="deckName"
        value={deckName}
        onChange={(e) => {
          setDeckName(e.target.value);
        }}
        className={styles.input}
      />
      <button className={styles.submitBtn} onClick={handleSubmit}>
        Добавить
      </button>
      <button type="button" className={styles.closeBtn} onClick={props.onClose}>
        Отменить
      </button>
    </form>
  );
};
