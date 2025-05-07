"use client";

import {
  Alert,
  Anchor,
  Button,
  Checkbox,
  Divider,
  Group,
  Paper,
  PaperProps,
  PasswordInput,
  Stack,
  Text,
  TextInput,
} from "@mantine/core";
import { useForm, type UseFormInput } from "@mantine/form";
import { upperFirst } from "@mantine/hooks";
import { GoogleButton, TwitterButton } from ".";
import { useRouter } from "next/navigation";
import styles from "@/css/auth-form.module.css";
import { authenticate } from "@/lib/actions";
import { useActionState } from "react";

const formConfig: UseFormInput<
  Record<string, any>,
  (values: Record<string, any>) => Record<string, any>
> = {
  initialValues: {
    email: String(),
    name: String(),
    password: String(),
    terms: true,
  },
  validate: {
    email: (val) => (/^\S+@\S+$/.test(val) ? null : "Invalid email"),
    password: (val) =>
      val.length >= 6 ? null : "Password should include at least 6 characters",
  },
};

const opposites = { login: "register", register: "login" };

export default function AuthenticationForm(
  props: PaperProps & { type: "login" | "register" },
) {
  const form = useForm(formConfig);
  const [errorMessage, formAction, isPending] = useActionState(
    authenticate,
    undefined,
  );
  const router = useRouter();
  const toggle = () => {
    router.push(`/${opposites[props.type]}`);
  };

  return (
    <div className={styles.auth_container}>
      <Paper
        radius="md"
        p="xl"
        withBorder
        className={styles.auth_paper}
        {...props}
      >
        <Text size="lg" fw={500}>
          Welcome to {<b>Mystic Madness</b>}, {props.type} with
        </Text>
        <Group grow mb="md" mt="md">
          <GoogleButton radius="xl">Google</GoogleButton>
          <TwitterButton radius="xl">Twitter</TwitterButton>
        </Group>

        <Divider
          label="Or continue with email"
          labelPosition="center"
          my="lg"
        />

        <form action={formAction}>
          <Stack>
            {props.type === "register" && (
              <TextInput
                label="Name"
                placeholder="Your name"
                value={form.values.name}
                onChange={(event) =>
                  form.setFieldValue("name", event.currentTarget.value)
                }
                radius="md"
              />
            )}

            <TextInput
              required
              label="Email"
              placeholder="user@mysticmadness.com"
              value={form.values.email}
              onChange={(event) =>
                form.setFieldValue("email", event.currentTarget.value)
              }
              error={form.errors.email && "Invalid email"}
              radius="md"
            />

            <PasswordInput
              required
              label="Password"
              placeholder="Your password"
              value={form.values.password}
              onChange={(event) =>
                form.setFieldValue("password", event.currentTarget.value)
              }
              error={
                form.errors.password &&
                "Password should include at least 6 characters"
              }
              radius="md"
            />

            {props.type === "register" && (
              <Checkbox
                label="I accept terms and conditions"
                checked={form.values.terms}
                onChange={(event) =>
                  form.setFieldValue("terms", event.currentTarget.checked)
                }
              />
            )}
          </Stack>

          <Group justify="space-between" mt="xl">
            <Anchor
              component="button"
              type="button"
              c="dimmed"
              onClick={() => toggle()}
              size="xs"
            >
              {props.type === "register"
                ? "Already have an account? Login"
                : "Don't have an account? Register"}
            </Anchor>
            <Button type="submit" radius="xl" disabled={isPending}>
              {upperFirst(props.type)}
            </Button>
          </Group>
        </form>
        {errorMessage && (
          <Alert color="red" title="Error" mt="md" variant="filled">
            {errorMessage}
          </Alert>
        )}
      </Paper>
    </div>
  );
}
