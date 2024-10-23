import { Analytics } from "@vercel/analytics/react";
import type { Metadata } from "next";
import "./globals.css";
import "./page.module.css";

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
