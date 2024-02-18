import React, { Component } from 'react'
import styles from './QuotationService.module.css';

export class QuotationService extends Component {
  render() {
    return (
<div className={styles.container}>
    <h1>Beräkna Offert</h1>

  <div className="p-8">
      <label htmlFor="stad" className="mt-4">Stad:</label>
      <select id="city" className="form-select px-2 py-2 ">
        <option value="Stockholm">Stockholm</option>
        <option value="Uppsala">Uppsala</option>
      </select>

      <label htmlFor="square-meters" className="mt-4">Kvadratmeter:</label>
      <input type="number" id="square-meters" className="form-control p-2" min="0" />

      <label htmlFor="optional-services" className="font-bold mt-4">Övriga tjänster:</label>

      <div className="mt-2">
        <div className="form-check">
          <input type="checkbox" id="windowCleaning" name="windowCleaning" className="form-check-input" />
          <label htmlFor="windowCleaning" className="form-check-label">Fönsterputsning</label>
        </div>
        <div className="form-check">
          <input type="checkbox" id="balconyCleaning" name="balconyCleaning" className="form-check-input" />
          <label htmlFor="balconyCleaning" className="form-check-label">Balkongstädning</label>
        </div>
        <div className="form-check">
          <input type="checkbox" id="trashRemoval" name="trashRemoval" className="form-check-input" />
          <label htmlFor="trashRemoval" className="form-check-label">Bortforsling av skräp</label>
        </div>
      </div>

    <div className="quote-result mt-4" id="quote-result">
      Pris: <span id="total-price" className="font-bold">0 kr</span>
    </div>
  </div>
</div>

    )
  }
}
