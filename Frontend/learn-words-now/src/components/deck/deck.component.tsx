import { useState } from "react";
import styles from "./deck.module.scss";
import { DeckInfo } from "./deckInfo/deckInfo";

export const DeckComponent = ({ name, id }: { name: string; id: string }) => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <>
      <button
        className={styles.card}
        onClick={() => {
          setIsOpen(true);
        }}
      >
        <p className={styles.cardName}>{name}</p>
      </button>
      <DeckInfo
        isOpen={isOpen}
        id={id}
        onClose={() => {
          setIsOpen(false);
        }}
      />
    </>
  );
};
