"use client";

import { faListCheck, faUser } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import styles from "./page.module.css";

export default function App() {
  return (
    <div className={styles.app}>
      <div>
        <ul>
          <li>
            <a href="">
              <FontAwesomeIcon icon={faListCheck} /> Get Started
            </a>
          </li>
          <li>
            <a href="">
              <FontAwesomeIcon icon={faUser} /> Login
            </a>
          </li>
        </ul>
      </div>

      <div className="hero-section">
        <h1>Transform Financial Data into Actionable Insights</h1>
        <h2>Real-time analytics to drive profitability and efficiency</h2>
      </div>

      <div className="features-section">
        <div className="headline-features">
          <h1>Real-time business metrics</h1>
        </div>

        <div className="reports-feature">
          <h3>Custom Reports</h3>
        </div>
        <div className="forecasting-feature">
          <h3>Forecasting Tools</h3>
        </div>
        <div className="data-feature">
          <h3>Data Security & Reliability</h3>
        </div>
      </div>
    </div>
  );
}
