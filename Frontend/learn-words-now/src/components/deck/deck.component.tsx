import styles from "./deck.module.scss";

export const DeckComponent = ({ name, id }: { name: string; id: string }) => {
  const toDeckPage = () => {
    console.log(id);
  };

  return (
    <button
      className={styles.card}
      onClick={() => {
        toDeckPage();
      }}
    >
      <p className={styles.cardName}>{name}</p>
    </button>
  );
};
