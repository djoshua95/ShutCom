import { Loader } from "@mantine/core";
import styles from "@/css/loader.module.css";

export default function Loading() {
  return (
    <div className={styles.loader_container}>
      <Loader size={50} />
    </div>
  );
}
