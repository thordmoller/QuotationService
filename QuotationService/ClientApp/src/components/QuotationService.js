import React, { Component } from 'react';
import styles from './QuotationService.module.css';

export class QuotationService extends Component {
  constructor(props) {
    super(props);
    this.state = {
      cities: [],
      services: [],
      loadingCities: true,
      loadingServices: false,

      selectedCity: 0,
      squareMeters: 40,
      totalPrice: 0
    };
  }

  async componentDidMount() {
    await this.fetchCities();
  }

  fetchCities = async () => {
    try {
      const response = await fetch('cities/names');
      if (!response.ok) {
        throw new Error('Failed to fetch cities data');
      }
      const data = await response.json();
      this.setState({ cities: data, loadingCities: false });

      // Väljer första staden i listan när de har hämtats
      if (data.length > 0) {
        const selectedId = data[0].id;
        await this.handleChange({ target: { name: "selectedCity", value: selectedId } });
      }
    } catch (error) {
      console.error('Error fetching cities data:', error);
      this.setState({ loadingCities: false });
    }
  };

  fetchServices = async (cityId) => {
    try {
      const response = await fetch(`cities/${cityId}/services`);
      if (!response.ok) {
        throw new Error('Failed to fetch optional services data');
      }
      const data = await response.json();
      //lägger till checkboxvärde
      const alteredData = data.map(service => ({
        ...service,
        checked: false
    }));
      this.setState({ services: alteredData, loadingServices: false });
    } catch (error) {
      console.error('Error fetching optional services data:', error);
      this.setState({ loadingServices: false });
    }
  };

  handleSubmit = async (e) => {
    const dataToSend =  {
        "cityId": this.state.selectedCity,
        "squareMeters": this.state.squareMeters,
        "services": this.state.services
    }
    const response = await fetch('quote', {
      method: 'POST',
      headers: {
        Accept: 'text/json',
        'Content-Type': 'text/json'
      },
      body: JSON.stringify(dataToSend)
    })
    const myData = await response.json();
    this.setState({totalPrice: myData});
  };

  handleChange = async (event) => {
    const { name, value, checked, id } = event.target;

    if (name === 'service') {
        //uppdatera checkboxens status
        let arr =[];
        this.state.services.map((service) => {
            if(service.id == id){
                let temp = {...service};
                temp.checked = checked;
                arr.push(temp)
            } else{
                arr.push(service)
            }
        });
        this.setState({services: arr}, () => {
            this.handleSubmit(event);
        });
    } else{
        this.setState({[name]: value}, () => {
            this.handleSubmit(event);
        })
    }

    if (name === 'selectedCity') {
      // rensa val av extratjänster när staden ändras
      this.setState({ loadingServices: true, services: [] });
      await this.fetchServices(value);
    }
};

  

  render() {
    const { cities, services, loadingServices } = this.state;

    return (
      <div className={styles.container}>
        <h1>Beräkna Offert</h1>
        <div className="p-8">
          <form ref="form" onChange={this.handleChange} onSubmit={this.handleSubmit}>
            <label htmlFor="city" className="mt-4">
              Stad:
            </label>
            <select id="selectedCity" name="selectedCity" className="form-select px-2 py-2">
              {cities.map((city) => (
                <option key={city.id} value={city.id}>
                  {city.name}
                </option>
              ))}
            </select>
            <label htmlFor="square-meters" className="mt-4">
              Kvadratmeter:
            </label>
            <input type="number" defaultValue={this.state.squareMeters} id="squareMeters" name="squareMeters" className="form-control p-2" min="0" />
            <label htmlFor="optional-services" className="font-bold mt-4">
              Övriga tjänster:
            </label>
            <div className="mt-2">
              {loadingServices ? (
                <p>Laddar...</p>
              ) : (
                services.map((service) => (
                  <div key={service.id} className="form-check">
                    <input type="checkbox"
                    id={service.id}
                    name={`service`}
                    className="form-check-input"/>
                    <label htmlFor={`service-${service.id}`} className="form-check-label">
                      {service.name}: {service.price} kr
                    </label>
                  </div>
                ))
              )}
            </div>
          </form>

          <div className="quote-result rounded  mt-5" id="quote-result">
            <span id="total-price" className='m-2'>Pris: <span className='text-success px-2'>{this.state.totalPrice}</span> :-</span>
          </div>
        </div>
      </div>
    );
  }
}
