"use server";
import { fetchClient } from "@/lib/fetchClient";

export async function triggerError(code: number) {
  return await fetchClient(`/questions/error?code=${code}`, "GET");
}
