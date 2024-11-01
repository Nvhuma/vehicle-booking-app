import React, { useState } from "react";
import style from "./BankCard.module.css";
import cardChip from './chip.png';
import contactlessImage from './contactless.png'; // Make sure to import this image
import mastercardImage from './mastercard.png';
import visaImage from './visa.png';



function BankCard({card}) {
	const {cardHolder, cardNumber, expiryDate, bankName} = card;

	function formatDate(dateStr) {
    const date = new Date(dateStr);
    const month = (date.getMonth() + 1).toString().padStart(2, "0"); // Ensure 2 digits for month
    const year = date.getFullYear().toString().slice(-2);
    return `${month}/${year}`;
  }

	function formatCardNumber(number) {
    return number.replace(/\s+/g, '').replace(/(\d{4})/g, '$1 ').trim();
  }

	function getCardType(number) {
    const firstDigit = number.slice(0, 1);

    switch (firstDigit) {
      case "4":
        return visaImage;
      case "2":
      case "5":
        return mastercardImage;
      default:
        return visaImage;
    }
  }

  return (
    <div className={`${style["bank-card"]} ${style["silver-card"]}`}>
      <span className={style["bank-name"]}>{bankName}</span>
      <div className={style["tap-and-chip-wrapper"]}>
        <div className={style["chip-image-container"]}>
          <img src={cardChip} alt="Chip" />
        </div>
        <div className={style["tap-sign"]}>
          <img src={contactlessImage} alt="Contactless" />
        </div>
      </div>
      <span className={style["card-number"]}>{formatCardNumber(cardNumber)}</span>
      <span className={style["expiry-date"]}>{formatDate(expiryDate)}</span>
      <div className={style["holder-and-type-wrapper"]}>
        <span className={style["name-on-card"]}>{cardHolder}</span>
        <div className={style["card-type-container"]}>
          <img src={getCardType(cardNumber)} alt="card-type" />
        </div>
      </div>
    </div>
  );
}

export default BankCard;