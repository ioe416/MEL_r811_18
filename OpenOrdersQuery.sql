SELECT Vendors.VendorName, PR_Details.Quantity,  PR_Details.Unit, Parts.PartNumber, Parts.PartDescription, PR_Details.Per, PR_Details.DueDate, PR_Details.Received 
                    FROM Parts INNER JOIN PR_Details ON Parts.PartID = PR_Details.PartID 
					INNER JOIN PR ON PR.OrderID = PR_Details.OrderID INNER JOIN Vendors ON PR.VendorID = Vendors.VendorID
					WHERE PR_Details.Received = 'False';