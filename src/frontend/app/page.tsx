export default async function HomePage() {
  await new Promise((resolve) => setTimeout(resolve, 1000));
  return <div>Home page</div>;
}
