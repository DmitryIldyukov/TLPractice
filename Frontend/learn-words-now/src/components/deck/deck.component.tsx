import { useState } from "react";
import styles from "./deck.module.scss";
import { DeckInfo } from "./deckInfo/deckInfo";

type DeckComponentProps = {
  name: string;
  id: string;
};

export const DeckComponent = (props: DeckComponentProps) => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <>
      <button
        className={styles.card}
        onClick={() => {
          setIsOpen(true);
        }}
      >
        <p className={styles.cardName}>{props.name}</p>
      </button>
      <DeckInfo
        isOpen={isOpen}
        id={props.id}
        onClose={() => {
          setIsOpen(false);
        }}
      />
    </>
  );
};
