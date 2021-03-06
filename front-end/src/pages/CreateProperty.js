import { useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import {
  Flex,
  Stack,
  useColorModeValue,
  Heading,
  Box,
  FormControl,
  FormLabel,
  Input,
  Button,
  Select,
  Checkbox,
  Text,
} from "@chakra-ui/react";

import serialize from "form-serialize";
import { createProperty } from "../redux/properties";

const CreateProperty = () => {
  const navigate = useNavigate();
  const { id: userId } = useSelector(state => state.auth);
  const dispatch = useDispatch();

  const img = useRef();
  const categoryList = [
    { name: "Apartment", value: "1" },
    { name: "Land", value: "3" },
    { name: "Villas", value: "2" },
    { name: "Building", value: "4" },
  ];
  const createHandler = e => {
    e.preventDefault();
    const enteredForm = serialize(e.target, { hash: true });
    const { name, files } = img.current;
    console.log(enteredForm);
    const form_data = new FormData();

    for (var key in enteredForm) {
      form_data.append(key, enteredForm[key]);
    }
    // HTML file input, chosen by user
    form_data.append(name, files[0]);

    form_data.append("userId", userId);

    dispatch(createProperty(form_data));
    navigate("/properties");
  };
  return (
    <>
      <Flex
        minH={"100vh"}
        align={"start"}
        justify={"center"}
        bg={useColorModeValue("gray.50", "gray.800")}
      >
        <Stack spacing={8} mx={"auto"} w='100vw' py={12} px={6}>
          <Stack align={"center"}>
            <Heading fontSize={"4xl"}>Create Real Estate</Heading>
          </Stack>
          <form onSubmit={createHandler} encType='multipart/form-data'>
            <Box
              rounded={"lg"}
              bg={useColorModeValue("white", "gray.700")}
              boxShadow={"lg"}
              p={8}
            >
              <Stack spacing={4}>
                <Stack direction={{ base: "column", md: "row" }}>
                  <FormControl>
                    <FormLabel htmlFor='Title'>Title</FormLabel>
                    <Input type='text' id='Title' name='Title' />
                  </FormControl>

                  <FormControl>
                    <Text htmlFor='Image'>Image</Text>
                    <Input
                      ref={img}
                      border='none'
                      mt={3}
                      type='file'
                      id='Image'
                      name='Image'
                    />
                  </FormControl>
                </Stack>

                <FormControl>
                  <FormLabel>Description</FormLabel>
                  <Input type='text' id='Description' name='Description' />
                </FormControl>

                <FormControl>
                  <FormLabel>VideoLink</FormLabel>
                  <Input type='text' id='VideoLink' name='VideoLink' />
                </FormControl>
                <FormControl>
                  <FormLabel>Price</FormLabel>
                  <Input type='number' id='Price' name='Price' />
                </FormControl>

                <FormControl>
                  <FormLabel>Area</FormLabel>
                  <Input type='number' id='Area' name='Area' />
                </FormControl>

                <Stack direction={{ base: "column", md: "row" }}>
                  <FormControl>
                    <FormLabel>State</FormLabel>
                    <Input
                      type='text'
                      id='Address.State'
                      name='Address.State'
                    />
                  </FormControl>

                  <FormControl>
                    <FormLabel>City</FormLabel>
                    <Input type='text' id='Address.City' name='Address.City' />
                  </FormControl>

                  <FormControl>
                    <FormLabel>Street</FormLabel>
                    <Input
                      type='text'
                      id='Address.Street'
                      name='Address.Street'
                    />
                  </FormControl>
                </Stack>

                <FormControl>
                  <FormLabel>Floor</FormLabel>
                  <Input type='number' id='Floor' name='Floor' />
                </FormControl>

                <Stack direction={{ base: "column", md: "row" }}>
                  <FormControl>
                    <FormLabel>Building Number</FormLabel>
                    <Input
                      type='number'
                      id='BuildingNumber'
                      name='BuildingNumber'
                    />
                  </FormControl>

                  <FormControl>
                    <FormLabel>Appartment Number</FormLabel>
                    <Input
                      type='number'
                      id='AppartmentNumber'
                      name='AppartmentNumber'
                    />
                  </FormControl>
                </Stack>

                <Stack direction={{ base: "column", md: "row" }}>
                  <FormControl>
                    <FormLabel>Rooms</FormLabel>
                    <Input type='number' id='Rooms' name='Rooms' />
                  </FormControl>

                  <FormControl>
                    <FormLabel>Baths</FormLabel>
                    <Input type='number' id='Baths' name='Baths' />
                  </FormControl>
                </Stack>

                <FormControl>
                  <FormLabel htmlFor='status'>Status</FormLabel>
                  <Select id='Status' name='Status'>
                    <option value='rent'>Rent</option>
                    <option value='sale'>Buy</option>
                  </Select>
                </FormControl>
                <FormControl isRequired>
                  <FormLabel htmlFor='CategoryId'>Category</FormLabel>
                  <Select id='CategoryId' name='CategoryId'>
                    {categoryList.map(item => (
                      <option value={item.value} key={item.value}>
                        {item.name}
                      </option>
                    ))}
                  </Select>
                </FormControl>

                <Stack direction={{ base: "column", md: "row" }}>
                  <FormControl>
                    <Checkbox id='SwimmingPool' name='SwimmingPool'>
                      SwimmingPool
                    </Checkbox>
                  </FormControl>

                  <FormControl>
                    <Checkbox id='LaundryRoom' name='LaundryRoom'>
                      LaundryRoom
                    </Checkbox>
                  </FormControl>

                  <FormControl>
                    <Checkbox id='EmergencyExit' name='EmergencyExit'>
                      EmergencyExit
                    </Checkbox>
                  </FormControl>

                  <FormControl>
                    <Checkbox id='FirePlace' name='FirePlace'>
                      FirePlace
                    </Checkbox>
                  </FormControl>
                </Stack>

                <Stack spacing={10}>
                  <Button
                    type='submit'
                    bg={"blue.400"}
                    color={"white"}
                    _hover={{
                      bg: "blue.500",
                    }}
                  >
                    Create
                  </Button>
                </Stack>
              </Stack>
            </Box>
          </form>
        </Stack>
      </Flex>
    </>
  );
};

export default CreateProperty;
