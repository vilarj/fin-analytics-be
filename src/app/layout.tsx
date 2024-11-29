import { Analytics } from "@vercel/analytics/react";
import type { Metadata } from "next";
import React from "react";
import "./styles/globals.css";
import "./styles/page.module.css";

export const metadata: Metadata = {
  title: "Fin-Analytics",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        {children}
        <Analytics />
      </body>
    </html>
  );
}
