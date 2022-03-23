import { Card, Col } from 'react-bootstrap';
import useStore from '../../app/store';
import Counter from '../Counter/Counter';

const Package = () => {
  const packages = useStore((state) => state.packages);

  return (
    <>
      {packages.map((pkg) => (
        <Col key={pkg.id}>
          <Card border='primary'>
            <Card.Header>${pkg.price}</Card.Header>
            <Card.Body>
              <Card.Title>{pkg.name}</Card.Title>
              <Card.Text>{pkg.description}</Card.Text>
            </Card.Body>
            <Card.Footer>
              <Counter packageId={pkg.id} price={pkg.price} />
            </Card.Footer>
          </Card>
        </Col>
      ))}
    </>
  );
};

export default Package;
