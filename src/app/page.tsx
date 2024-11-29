"use client";

import { faListCheck, faUser } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Link from "next/link";
import styles from "./styles/page.module.css";

export default function App() {
  return (
    <div className={styles.container}>
      {/* Navigation Bar */}
      <header className={styles.navbar}>
        <ul className={styles.navLinks}>
          <li>
            <Link href="/">
              <FontAwesomeIcon icon={faListCheck} /> Get Started
            </Link>
          </li>
          <li>
            <Link href="/login">
              <FontAwesomeIcon icon={faUser} /> Login
            </Link>
          </li>
        </ul>
      </header>

      {/* Hero Section */}
      <section className={styles.heroSection}>
        <h1 className={styles.heroTitle}>
          Transform Financial Data into Actionable Insights
        </h1>
        <h2 className={styles.heroSubtitle}>
          Real-time analytics to drive profitability and efficiency
        </h2>
      </section>

      {/* Features Section */}
      <section className={styles.featuresSection}>
        <div className={styles.headlineFeatures}>
          <h1>Real-time business metrics</h1>
        </div>
        <div className={styles.featureCard}>
          <h3>Custom Reports</h3>
          <p>Create detailed reports tailored to your business needs.</p>
        </div>
        <div className={styles.featureCard}>
          <h3>Forecasting Tools</h3>
          <p>Accurate tools for predicting business trends.</p>
        </div>
        <div className={styles.featureCard}>
          <h3>Data Security & Reliability</h3>
          <p>State-of-the-art security measures for your data.</p>
        </div>
      </section>
    </div>
  );
}
