import { NextResponse } from "next/server";
import { auth } from "./auth";

export default auth((req) => {
  if (req.auth) return NextResponse.next();

  const { nextUrl } = req;
  const callbackUrl = encodeURIComponent(nextUrl.pathname + nextUrl.search);
  return NextResponse.redirect(
    new URL(`/auth-gate?callback=${callbackUrl}`, nextUrl),
  );
});

export const config = {
  matcher: ["/question/ask", "/questions/:id/edit", "session"],
};
