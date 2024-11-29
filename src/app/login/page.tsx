"use client";

import { useState } from "react";
import styles from "../styles/login.module.css";

export default function LoginPage() {
  const [loginMethod, setLoginMethod] = useState<"email" | "phone">("email");
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (loginMethod === "email") {
      console.log("Email:", email);
      console.log("Password:", password);
    } else {
      console.log("Phone:", phone);
    }
  };

  const handleGoogleLogin = () => {
    // TODO: Implement integration with 3rd party
    console.log("Google Login triggered");
  };

  const handleAppleLogin = () => {
    // TODO: Implement integration with 3rd party
    console.log("Apple Login triggered");
  };

  return (
    <div className={styles.container}>
      <div className={styles.card}>
        <h1 className={styles.title}>Welcome Back</h1>
        <form onSubmit={handleSubmit} className={styles.form}>
          {/* Toggle Between Email and Phone */}
          <div className={styles.toggleGroup}>
            <button
              type="button"
              className={`${styles.toggleButton} ${
                loginMethod === "email" ? styles.activeToggle : ""
              }`}
              onClick={() => setLoginMethod("email")}
            >
              Email
            </button>
            <button
              type="button"
              className={`${styles.toggleButton} ${
                loginMethod === "phone" ? styles.activeToggle : ""
              }`}
              onClick={() => setLoginMethod("phone")}
            >
              Phone
            </button>
          </div>

          {/* Email Login Form */}
          {loginMethod === "email" && (
            <>
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
            </>
          )}

          {/* Phone Login Form */}
          {loginMethod === "phone" && (
            <div className={styles.inputGroup}>
              <label htmlFor="phone" className={styles.label}>
                Phone Number
              </label>
              <input
                type="tel"
                id="phone"
                className={styles.input}
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
                placeholder="Enter your phone number"
                required
              />
            </div>
          )}

          {/* Submit Button */}
          <button type="submit" className={styles.button}>
            {loginMethod === "email" ? "Login" : "Continue"}
          </button>
        </form>

        {/* Divider */}
        <div className={styles.divider}>or</div>

        {/* Social Login Options */}
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

        {/* Footer */}
        {loginMethod === "email" && (
          <p className={styles.footer}>
            Don&apos;t have an account?{" "}
            <a href="/signup" className={styles.link}>
              Sign Up
            </a>
          </p>
        )}
      </div>
    </div>
  );
}
