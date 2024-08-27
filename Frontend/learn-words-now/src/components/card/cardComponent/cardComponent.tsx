import { useApplicationStore } from "../../../store/store";
import { Card } from "../../../types/card/card.model";
import styles from "./cardComponent.module.scss";

export const CardComponent = ({ deckId, card }: { deckId: string; card: Card }) => {
  const appStore = useApplicationStore();

  const onDelete = () => {
    appStore.deleteCardById(deckId, card.id);
  };

  return (
    <div className={styles.line}>
      <p className={styles.info}>
        {card.frontSide}/{card.backSide}
      </p>
      <button
        className={styles.delBtn}
        onClick={() => {
          onDelete();
        }}
      >
        Удалить
      </button>
    </div>
  );
};
