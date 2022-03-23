import { Form } from 'react-bootstrap';
import useStore from '../../app/store';

const Customer = () => {
  const { selectCustomer, calculateWholeCart, customers } = useStore(
    (state) => state
  );

  return (
    <>
      <span>Select customer:</span>
      <Form.Select
        aria-label='Default select example'
        onChange={(e) => {
          selectCustomer(parseInt(e.currentTarget.value));
          calculateWholeCart();
        }}
      >
        {customers.map((customer) => (
          <option key={customer.id} value={customer.id}>
            {customer.name}
          </option>
        ))}
      </Form.Select>
    </>
  );
};

export default Customer;
