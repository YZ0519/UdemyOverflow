"use client";

import { Avatar } from "@heroui/avatar";
import {
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownTrigger,
} from "@heroui/dropdown";
import { User } from "next-auth";
import { signOut } from "next-auth/react";

type Props = {
  user: User;
};

export default function UserMenu({ user }: Props) {
  return (
    <Dropdown>
      <DropdownTrigger>
        <div className="flex items-center gap-2 cursor-pointer">
          <Avatar
            suppressHydrationWarning
            color="secondary"
            size="sm"
            name={user.displayName?.charAt(0)}
          />
          {user.displayName}
        </div>
      </DropdownTrigger>
      <DropdownMenu>
        <DropdownItem href={`/profiles/${user.id}`} key="edit">
          Edit Profile
        </DropdownItem>
        <DropdownItem
          onClick={() => signOut({ redirectTo: "/" })}
          key="logout"
          className="text-danger"
          color="danger"
        >
          Logout
        </DropdownItem>
      </DropdownMenu>
    </Dropdown>
  );
}
