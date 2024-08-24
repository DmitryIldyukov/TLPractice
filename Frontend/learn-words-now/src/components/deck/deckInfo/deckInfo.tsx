import styles from "./deckInfo.module.scss";

type DeckInfoProps = {
  isOpen: boolean;
  handleClose: () => void;
};

export const DeckInfo = (props: DeckInfoProps) => {
  const startLearningProcess = () => {};

  return (
    <div className={props.isOpen ? styles.card : styles.hidden}>
      <button onClick={}>Учить</button>
    </div>
  );
};
