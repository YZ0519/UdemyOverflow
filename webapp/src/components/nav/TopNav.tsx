import Link from "next/link";
import { Button } from "@heroui/button";
import { AcademicCapIcon } from "@heroicons/react/24/solid";
import ThemeToggle from "./ThemeToggle";
import SearchInput from "./SearchInput";

export default function TopNav() {
  return (
    <header className="p-2 w-full fixed top-0 z-50 border-b bg-white dark:bg-black">
      <div className="flex px-10 mx-auto">
        <div className="flex items-center gap-6">
          <Link href="/" className="flex items-center gap-3 max-h-16">
            <AcademicCapIcon className="size-10 text-secondary" />
            <h3 className="text-xl font-semibold uppercase">Overflow</h3>
          </Link>
          <nav className="flex gap-3 my-2 text-md text-neutral-500">
            <Link href="/">About</Link>
            <Link href="/">Contact</Link>
            <Link href="/">Help</Link>
          </nav>
        </div>
        <SearchInput />
        <div className="flex basis-1/4 shrink-0 justify-end gap-3">
          <ThemeToggle />
          <Button color="secondary" variant="bordered">
            Login
          </Button>
          <Button color="secondary">Register</Button>
        </div>
      </div>
    </header>
  );
}
