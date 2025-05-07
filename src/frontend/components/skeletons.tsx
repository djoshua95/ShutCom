import { Skeleton, Paper, Divider, Group, Stack } from "@mantine/core";
import styles from "@/css/auth-form.module.css";

export function AuthenticationFormSkeleton() {
  return (
    <div className={styles.auth_container}>
      <Paper radius="md" p="xl" withBorder className={styles.auth_paper}>
        <Skeleton height={24} width="60%" mb="md" />
        <Group grow mb="md" mt="md">
          <Skeleton height={40} radius="xl" />
          <Skeleton height={40} radius="xl" />
        </Group>

        <Divider
          label={<Skeleton height={16} width={120} />}
          labelPosition="center"
          my="lg"
        />

        <Stack>
          <Skeleton height={40} radius="md" />
          <Skeleton height={40} radius="md" />
          <Skeleton height={40} radius="md" />
        </Stack>

        <Group justify="space-between" mt="xl">
          <Skeleton height={16} width="40%" />
          <Skeleton height={36} width={80} radius="xl" />
        </Group>
      </Paper>
    </div>
  );
}
