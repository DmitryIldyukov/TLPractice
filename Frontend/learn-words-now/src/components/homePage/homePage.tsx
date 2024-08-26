import styles from "./homePage.module.scss";
import { DeckComponent } from "../deck/deck.component";
import { useApplicationStore } from "../../store/store";
import { AddDeckComponent } from "../deck/addDeckComponent/addDeckComponent";
import { useState } from "react";

export const HomePage = () => {
  const [isAddDeckOpen, setIsAddDeckOpen] = useState(false);
  const appStore = useApplicationStore();

  return (
    <div className={styles.container}>
      <div className={styles.content}>
        <div className={styles.toolbar}>
          <button
            className={styles.btn}
            onClick={() => {
              setIsAddDeckOpen(true);
            }}
          >
            + Добавить группу карточек
          </button>
        </div>
        <AddDeckComponent
          isOpen={isAddDeckOpen}
          onClose={() => {
            setIsAddDeckOpen(false);
          }}
        />
        <div className={styles.decks}>
          {appStore.app.decks.map((deck) => (
            <DeckComponent key={deck.id} id={deck.id} name={deck.name} />
          ))}
        </div>
      </div>
    </div>
  );
};
