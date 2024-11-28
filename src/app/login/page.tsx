"use client";

import { useState } from "react";
import styles from "../styles/login.module.css";

export default function LoginPage() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    console.log("Email:", email);
    console.log("Password:", password);
  };

  const handleGoogleLogin = () => {
    console.log("Google Login triggered");
    // Replace with logic to call your backend
  };

  const handleAppleLogin = () => {
    console.log("Apple Login triggered");
    // Replace with logic to call your backend
  };

  return (
    <div className={styles.container}>
      <div className={styles.card}>
        <h1 className={styles.title}>Welcome Back</h1>
        <form onSubmit={handleSubmit} className={styles.form}>
          <div className={styles.inputGroup}>
            <label htmlFor="email" className={styles.label}>
              Email
            </label>
            <input
              type="email"
              id="email"
              className={styles.input}
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="Enter your email"
              required
            />
          </div>
          <div className={styles.inputGroup}>
            <label htmlFor="password" className={styles.label}>
              Password
            </label>
            <input
              type="password"
              id="password"
              className={styles.input}
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="Enter your password"
              required
            />
          </div>
          <button type="submit" className={styles.button}>
            Login
          </button>
        </form>
        <div className={styles.divider}>or</div>
        <div className={styles.socialLogin}>
          <button
            onClick={handleGoogleLogin}
            className={`${styles.button} ${styles.googleButton}`}
          >
            Sign in with Google
          </button>
          <button
            onClick={handleAppleLogin}
            className={`${styles.button} ${styles.appleButton}`}
          >
            Sign in with Apple
          </button>
        </div>
        <p className={styles.footer}>
          Don't have an account?{" "}
          <a href="/signup" className={styles.link}>
            Sign Up
          </a>
        </p>
      </div>
    </div>
  );
}
