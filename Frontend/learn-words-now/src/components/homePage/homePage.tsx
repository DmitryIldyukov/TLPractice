import styles from "./homePage.module.scss";
import { DeckComponent } from "../deck/deck.component";
import { useApplicationStore } from "../../store/store";

export const HomePage = () => {
  const decks = useApplicationStore((state) => state.decks);

  return (
    <div className={styles.container}>
      <div className={styles.content}>
        <div className={styles.toolbar}>
          <button className={styles.btn}>+ Добавить группу карточек</button>
        </div>
        <div className={styles.decks}>
          {decks.map((deck) => (
            <DeckComponent key={deck.id} id={deck.id} name={deck.name} />
          ))}
        </div>
      </div>
    </div>
  );
};
