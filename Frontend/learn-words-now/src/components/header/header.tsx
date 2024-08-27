import styles from "./header.module.scss";
import logo from "../../assets/logo.svg";

export const Header = () => {
  return (
    <div className={styles.header}>
      <div className={styles.content}>
        <div className={styles.logo}>
          <p className={styles.logoTitle}>LearnWordsNow</p>
          <img src={logo} alt="logo" />
        </div>
      </div>
    </div>
  );
};
