import {
  Input,
  Stack,
  Flex,
  Textarea,
  Heading,
  Box,
  InputRightElement,
  FormControl,
  InputLeftElement,
  InputLeftAddon,
  InputGroup,
  Checkbox,
  Link,
  Button,
  FormLabel,
} from "@chakra-ui/react";
import { useColorModeValue } from "@chakra-ui/react";
import { PhoneIcon, CheckIcon } from "@chakra-ui/icons";

const AddProduct = () => {
  return (
    <Flex
    as='cite'
      minH={"100vh"}
      align={"center"}
      justify={"center"}
      bg={useColorModeValue("gray.50", "gray.800")}
    >
      <Stack spacing={2} mx={"auto"} maxW={"lg"} py={5} px={2}>
        <Stack align={"center"}>
          <Heading fontSize={"4xl"}>Add Real State</Heading>
        </Stack>
        <form action="submit">
          <Box
            rounded={"lg"}
            bg={useColorModeValue("white", "gray.700")}
            boxShadow={"lg"}
            p={8}
          >
            <Stack spacing={1}>
              <FormControl isRequired>
                <FormLabel>Title</FormLabel>
                <Input
                  type="text"
                  name="title"
                  placeholder="Like:Apartments For sale in Sohag"
                />
              </FormControl>
              <FormControl>
                <FormLabel>image</FormLabel>
                <Input py={1} type="file" name="image" placeholder="" />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Description</FormLabel>
                <Textarea type="text" name="image" placeholder="" />
              </FormControl>
              <InputGroup isRequired>
                <InputLeftElement
                  pointerEvents="none"
                  color="gray.300"
                  fontSize="1.2em"
                  children="$"
                />
                <Input placeholder="Enter your Price" isRequired />
                <InputRightElement children={<CheckIcon color="green.500" />} />
              </InputGroup>
              <InputGroup>
                <InputLeftElement
                  pointerEvents="none"
                  children={<PhoneIcon color="gray.300" />}
                />
                <Input type="tel" placeholder="Phone number" />
              </InputGroup>
              <Stack
                direction={{ base: "column", sm: "row" }}
                align={"start"}
                justify={"space-between"}
              >
                <Input
                  placeholder="Area"
                  htmlSize={4}
                  width="auto"
                  isRequired
                />
                <Input
                  placeholder="State"
                  htmlSize={4}
                  width="auto"
                  isRequired
                />
                <Input
                  placeholder="City"
                  htmlSize={4}
                  width="auto"
                  isRequired
                />
                <Input
                  placeholder="Status"
                  htmlSize={4}
                  width="auto"
                  isRequired
                />
              </Stack>
              <Stack
                direction={{ base: "column" }}
                align={"start"}
                justify={"space-between"}
              >
                <Stack spacing={5} direction="row">
                  <Checkbox colorScheme="green">
                  Swimming Pool
                  </Checkbox>
                  <Checkbox colorScheme="green">
                  Laundry Room
                  </Checkbox>
                </Stack>
                <Stack spacing={5} direction="row">
                <Checkbox colorScheme="green">
                  Emergency Exit
                  </Checkbox>
                  <Checkbox colorScheme="green">
                  Fire Place
                  </Checkbox>
                </Stack>

              </Stack>
              <Stack spacing={10}>
                <Button
                  type="submit"
                  bg={"blue.400"}
                  color={"white"}
                  _hover={{
                    bg: "blue.500",
                  }}
                >
                  Add
                </Button>
              </Stack>
            </Stack>
          </Box>
        </form>
      </Stack>
    </Flex>
  );
};

export default AddProduct;
